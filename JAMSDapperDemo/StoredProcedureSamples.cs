using Dapper;
using JAMSDapperDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JAMSDapperDemo
{
    /// <summary>
    /// Stored procedure samples
    /// </summary>
    public class StoredProcedureSamples
    {
        /// <summary>
        /// Jams IDb connection
        /// </summary>
        private readonly IDbConnection jamsContextConnection;

        /// <summary>
        /// Creates new instance of stored procedure samples
        /// </summary>
        public StoredProcedureSamples(IDbConnection jamsDapper)
        {
            this.jamsContextConnection = jamsDapper;
        }

        /// <summary>
        /// Find agent sp
        /// </summary>
        /// <returns></returns>
        public Agent FindAgent()
        {
            // find agent sp
            var spFindAgent = "FindAgent";
            var agentDictionary = new Dictionary<int, Agent>();

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // multi mapping query 
            var listFindAgents = jamsContextConnection.Query<Agent, AgentProperty, PropertyDefinition, Category, Agent>(
                    spFindAgent,
                    (agent, agentProperty, propertyDefinition, category) =>
                    {
                        if (!agentDictionary.TryGetValue(agent.AgentId, out var agentEntry))
                        {
                            agentEntry = agent;
                            agentEntry.AgentProperties = new List<AgentProperty>();
                            agentDictionary.Add(agentEntry.AgentId, agentEntry);
                        }

                        agentProperty.PropertyDefinition = propertyDefinition;
                        agentProperty.PropertyDefinition.Category = category;
                        agentEntry.AgentProperties.Add(agentProperty);
                        return agentEntry;
                    },
                    new { agent_name = "AgentFromDapperSPTest", tenant_id = 1 },
                    splitOn: "PropertyId, CategoryId, CategoryName",
                    commandType: CommandType.StoredProcedure,
                    transaction: transaction)
                .Distinct()
                .FirstOrDefault();

            // commit transaction
            transaction.Commit();

            return listFindAgents;
        }

        /// <summary>
        /// Get agent sp
        /// </summary>
        /// <returns></returns>
        public Agent GetAgent()
        {
            // get agent sp
            var spGetAgent = "GetAgent";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // query multiple
            var multiResultGetAgent = jamsContextConnection.QueryMultiple(spGetAgent,
                new { agent_name = "AgentFromDapperSPTest", tenant_id = 1, agent_id = 3017 },
                commandType: CommandType.StoredProcedure,
                transaction: transaction);

            // map results
            var agent = multiResultGetAgent.Read<Agent>().FirstOrDefault();
            var agentProperties = multiResultGetAgent.Read<AgentProperty, PropertyDefinition, Category, AgentProperty>((agentProperty, propertyDefinition, category) =>
            {
                agentProperty.PropertyDefinition = propertyDefinition;
                agentProperty.PropertyDefinition.Category = category;
                return agentProperty;
            }, splitOn: "CategoryId, CategoryName").ToList();

            // commit transaction
            transaction.Commit();

            agent.AgentProperties = agentProperties;
            return agent;
        }

        /// <summary>
        /// Insert Agent Sp
        /// </summary>
        /// <returns></returns>
        public int InsertAgent()
        {
            var spInsertAgent = "InsertAgent";

            // parameters for insert
            var insertAgentParams = new DynamicParameters();
            insertAgentParams.Add("@agent_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            insertAgentParams.Add("@last_change", dbType: DbType.DateTime2, direction: ParameterDirection.Output);
            insertAgentParams.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            insertAgentParams.Add("@agent_name", "AgentFromDapperSPTest");
            insertAgentParams.Add("@last_changed_by", "DapperUser");
            insertAgentParams.Add("@description", "Agent from Dapper SP demo");
            insertAgentParams.Add("@tenant_id", 1);
            insertAgentParams.Add("@agent_type_name", "Local");
            insertAgentParams.Add("@platform_type_name", "Windows");
            insertAgentParams.Add("@online", 1);
            insertAgentParams.Add("@agentUid", Guid.NewGuid());
            insertAgentParams.Add("@acl", Array.Empty<byte>());
            insertAgentParams.Add("@job_limit", 999);

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // insert agent
            var spInsertAgentResult = jamsContextConnection.Execute(spInsertAgent,
                insertAgentParams,
                commandType: CommandType.StoredProcedure,
                transaction: transaction);

            // commit transaction
            transaction.Commit();

            // get out params
            var resultAgentId = insertAgentParams.Get<int>("@agent_id");

            return resultAgentId;
        }

        /// <summary>
        /// Delete agent sp
        /// </summary>
        public void DeleteAgent(int agentId)
        {
            // sp name
            var spDeleteAgent = "DeleteAgent";

            // begin dapper transaction
            using var transaction = jamsContextConnection.BeginTransaction();

            // execute delete sp
            jamsContextConnection.Execute(spDeleteAgent,
                new { agent_name = "AgentFromDapperSPTest", tenant_id = 1, agent_id = agentId, last_changed_by = "" },
                commandType: CommandType.StoredProcedure, transaction: transaction);

            // commit transaction
            transaction.Commit();

        }
    }
}
