using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using JAMSDapperDemo.Model;

namespace JAMSDapperDemo
{
    /// <summary>
    /// Basic operation samples
    /// </summary>
    public class BasicOperationsSamples
    {
        /// <summary>
        /// Jams IDb connection
        /// </summary>
        private readonly IDbConnection jamsContextConnection;

        /// <summary>
        /// Creates new instance of basic operations
        /// </summary>
        /// <param name="jamsDapper"></param>
        public BasicOperationsSamples(IDbConnection jamsDapper)
        {
            this.jamsContextConnection = jamsDapper;
        }

        /// <summary>
        /// Add agent
        /// </summary>
        public void AddAgent()
        {
            // create insert query
            var sqlAgentInsert = new StringBuilder();
            sqlAgentInsert.AppendLine("INSERT INTO Agent (AgentName, Description, LastChangedBy, LastChange, TenantId, AgentElementTypeId, PlatformElementTypeId, JobLimit, Online, AgentUid ) ");
            sqlAgentInsert.AppendLine("Values (@AgentName, @LastChangedBy, @Description, @LastChange, @TenantId, @AgentElementTypeId, @PlatformElementTypeId, @JobLimit, @Online, @AgentUid);");

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // execute
            jamsContextConnection.Execute(sqlAgentInsert.ToString(),
                new
                {
                    AgentName = "AgentFromDapper",
                    LastChangedBy = "DapperUser",
                    Description = "Agent from Dapper demo",
                    LastChange = new DateTime(2021, 01, 01, 0, 0, 0),
                    TenantId = 1,
                    AgentElementTypeId = 84,
                    PlatformElementTypeId = 104,
                    JobLimit = 999,
                    Online = 1,
                    AgentUid = Guid.NewGuid()
                }, transaction);

            // commit transaction
            transaction.Commit();
        }

        /// <summary>
        /// Get agent
        /// </summary>
        public Agent GetAgent()
        {
            // select agent sql
            var sqlGetAgent = "Select * FROM Agent WHERE AgentName = @AgentName";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // query
            var dapperAgent = jamsContextConnection.Query<Agent>(sqlGetAgent, new { AgentName = "AgentFromDapper" }, transaction).FirstOrDefault();

            // commit transaction
            transaction.Commit();

            return dapperAgent;
        }

        /// <summary>
        /// Update agent
        /// </summary>
        public void UpdateAgent(Agent agent)
        {
            // update agent sql
            var sqlUpdateAgent = "Update Agent set Description = @Description where AgentId = @AgentId";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // execute
            jamsContextConnection.Execute(sqlUpdateAgent, new { Description = "Updated agent form Dapper", agent.AgentId }, transaction);

            // commit transaction
            transaction.Commit();
        }

        /// <summary>
        /// Delete agent
        /// </summary>
        public int DeleteAgent(Agent agent)
        {
            // delete agent sql 
            var sqlDeleteAgent = "DELETE FROM Agent WHERE AgentName = @AgentName";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // execute
            var result = jamsContextConnection.Execute(sqlDeleteAgent, new { AgentName = "AgentFromDapper" }, transaction);

            // commit transaction
            transaction.Commit();

            return result;
        }

        /// <summary>
        /// Get job by id
        /// </summary>
        public Job GetJobById()
        {
            var getJobById = "SELECT * FROM Job WHERE JobId = @JobId;";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            var job = jamsContextConnection.Query<Job>(getJobById, new { JobId = 40 }, transaction).FirstOrDefault();

            // commit transaction
            transaction.Commit();

            return job;
        }

        /// <summary>
        /// Get job by id  with navigation props
        /// </summary>
        public Job GetJobByIdWithNavigationProps()
        {
            var jobDictionary = new Dictionary<int, Job>();

            // create query
            var query = new StringBuilder();
            query.AppendLine("SELECT *");
            query.AppendLine("FROM [Job] AS[j]");
            query.AppendLine("LEFT JOIN [Param] AS[p] ON([j].[TenantId] = [p].[TenantId]) AND([j].[JobId] = [p].[JobId])");
            query.AppendLine("LEFT JOIN [JobElement] AS[j0] ON([j].[TenantId] = [j0].[TenantId]) AND([j].[JobId] = [j0].[JobId]) ");
            query.AppendLine("LEFT JOIN [JobProperty] AS[j1] ON([j].[TenantId] = [j1].[TenantId]) AND([j].[JobId] = [j1].[JobId]) ");
            query.AppendLine("WHERE ([j].[TenantId] = 1) AND([j].[JobId] = 40)");
            query.AppendLine("ORDER BY [j].[JobId], [j].[TenantId], [p].[TenantId], [p].[JobId], [p].[ParamId], [j0].[TenantId], [j0].[JobId], [j0].[ElementId], [j1].[TenantId], [j1].[JobId], [j1].[PropertyId]");

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            var job = jamsContextConnection.Query<Job, Param, JobElement, JobProperty, Job>(query.ToString(),
                    (job, param, jobElement, jobProperty) =>
                    {
                        if (!jobDictionary.TryGetValue(job.JobId, out var jobEntry))
                        {
                            jobEntry = job;
                            jobEntry.Params = new List<Param>();
                            jobEntry.JobElements = new List<JobElement>();
                            jobEntry.JobProperties = new List<JobProperty>();
                            jobDictionary.Add(jobEntry.JobId, jobEntry);
                        }

                        if (param != null)
                        {
                            jobEntry.Params.Add(param);
                        }

                        if (jobElement != null)
                        {
                            jobEntry.JobElements.Add(jobElement);

                        }

                        if (jobProperty != null)
                        {
                            jobEntry.JobProperties.Add(jobProperty);
                        }
                        return jobEntry;
                    },
                    param: null,
                    splitOn: "ParamId, ElementId, PropertyId",
                    commandType: CommandType.Text,
                    transaction: transaction)
                .Distinct()
                .ToList();

            // commit transaction
            transaction.Commit();

            return job.FirstOrDefault();
        }

        /// <summary>
        /// Get Job with navigation props
        /// </summary>
        /// <returns></returns>
        public List<Job> GetAllJobsWithNavigationProps()
        {
            var jobDictionary = new Dictionary<int, Job>();

            // create query          
            var query = new StringBuilder();
            query.AppendLine("SELECT *");
            query.AppendLine("FROM[Job] AS[j]");
            query.AppendLine("LEFT JOIN[Param] AS[p] ON([j].[TenantId] = [p].[TenantId]) AND([j].[JobId] = [p].[JobId])");
            query.AppendLine("LEFT JOIN[JobElement] AS[j0] ON([j].[TenantId] = [j0].[TenantId]) AND([j].[JobId] = [j0].[JobId])");
            query.AppendLine("LEFT JOIN[JobProperty] AS[j1] ON([j].[TenantId] = [j1].[TenantId]) AND([j].[JobId] = [j1].[JobId])");
            query.AppendLine("WHERE [j].[TenantId] = 1");
            query.AppendLine("ORDER BY[j].[JobId], [j].[TenantId], [p].[TenantId], [p].[JobId], [p].[ParamId], [j0].[TenantId], [j0].[JobId], [j0].[ElementId], [j1].[TenantId], [j1].[JobId], [j1].[PropertyId]");

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            var jobs = jamsContextConnection.Query<Job, Param, JobElement, JobProperty, Job>(query.ToString(),
                    (job, param, jobElement, jobProperty) =>
                    {
                        if (!jobDictionary.TryGetValue(job.JobId, out var jobEntry))
                        {
                            jobEntry = job;
                            jobEntry.Params = new List<Param>();
                            jobEntry.JobElements = new List<JobElement>();
                            jobEntry.JobProperties = new List<JobProperty>();
                            jobDictionary.Add(jobEntry.JobId, jobEntry);
                        }
                        jobEntry.Params.Add(param);
                        jobEntry.JobElements.Add(jobElement);
                        jobEntry.JobProperties.Add(jobProperty);
                        return jobEntry;
                    },
                    param: null,
                    splitOn: "ParamId, ElementId, PropertyId",
                    commandType: CommandType.Text,
                    transaction: transaction)
                .Distinct()
                .ToList();

            // commit transaction
            transaction.Commit();

            return jobs;
        }

        /// <summary>
        /// Get all jobs wih navigation properties
        /// </summary>
        public List<Job> GetAllJobsByTenant()
        {
            // get all by tenant
            var getAllJobsByTenantId = "SELECT * FROM Job WHERE TenantId = @TenantId;";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            var jobs = jamsContextConnection.Query<Job>(getAllJobsByTenantId, new { TenantId = 1 }, transaction).ToList();

            // commit transaction
            transaction.Commit();

            return jobs;
        }
    }
}
