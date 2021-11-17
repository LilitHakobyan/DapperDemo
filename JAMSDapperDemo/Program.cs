using System;
using System.Data;
using System.Linq;
using Dapper;
using JAMSDapperDemo.Model;

namespace JAMSDapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlAgents = "SELECT TOP 5 * FROM Agent;";
            string sqlJob = "SELECT * FROM Job WHERE JobId = @JobId;";
            string sqlAgentInsert = "INSERT INTO Agent (AgentName, Description, LastChangedBy, LastChange, TenantId, AgentElementTypeId, PlatformElementTypeId, JobLimit, Online, AgentUid ) " +
                                    "Values (@AgentName, @LastChangedBy, @Description, @LastChange, @TenantId, @AgentElementTypeId, @PlatformElementTypeId, @JobLimit, @Online, @AgentUid);";

            var jamsContextConnection = new JAMSDapperContext().CreateConnection();

            //Single =  Execute a single time a SQL Command.
            var affectedRows = jamsContextConnection.Execute(sqlAgentInsert,
                new
                {
                    AgentName = "DapperAgent1",
                    LastChangedBy = "DapperUser",
                    Description = "Agent from Dapper demo",
                    LastChange = new DateTime(2021, 01, 01, 0, 0, 0),
                    TenantId = 1,
                    AgentElementTypeId = 84,
                    PlatformElementTypeId = 104,
                    JobLimit = 999,
                    Online = 1,
                    AgentUid = Guid.NewGuid()
                });

            Console.WriteLine(affectedRows);

            // Only for see the Insert.
            var dapperAgent = jamsContextConnection.Query<Agent>("Select * FROM Agent WHERE AgentName = 'DapperAgent'").FirstOrDefault();

            Console.WriteLine(dapperAgent?.Description);

            var sp = "FindAgent";
            var spAffectedRows = jamsContextConnection.Execute(sp,
                new { @agent_name = "DapperAgent", @tenant_id = 1 },
                commandType: CommandType.StoredProcedure);

            Console.WriteLine(spAffectedRows);
        }
    }
}
    