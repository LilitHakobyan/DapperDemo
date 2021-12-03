using JAMSDapperDemo.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace JAMSDapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWa = new Stopwatch();
            var filePath = @"C:\Users\Lilit.Hakobyan\Documents\EFDapperDemo\DapperResults.csv";
            var performanceData = new StringBuilder();

            // create IDb connection
            using var jamsContextConnection = new JAMSDapperContext().CreateConnection();

            // open connection
            jamsContextConnection.Open();

            // create basic operation instance 
            var basicOperation = new BasicOperationsSamples(jamsContextConnection);
            basicOperation.GetAgent();

            //Single =  Execute a single time a SQL Command.
            stopWa.Reset();
            stopWa.Start();
            basicOperation.AddAgent();
            stopWa.Stop();
            performanceData.AppendLine($"Add Agent , {stopWa.ElapsedMilliseconds}ms");

            // Only for see the Insert.
            stopWa.Reset();
            stopWa.Start();
            var dapperAgent = basicOperation.GetAgent();
            stopWa.Stop();
            performanceData.AppendLine($"Get Agent , {stopWa.ElapsedMilliseconds}ms");

            // Only for see the Insert.
            stopWa.Reset();
            stopWa.Start();
            basicOperation.UpdateAgent(dapperAgent);
            stopWa.Stop();
            performanceData.AppendLine($"Update Agent , {stopWa.ElapsedMilliseconds}ms");
            Console.WriteLine(dapperAgent?.Description);

            // delete agent
            stopWa.Reset();
            stopWa.Start();
            basicOperation.DeleteAgent(dapperAgent);
            stopWa.Stop();
            performanceData.AppendLine($"Delete Agent , {stopWa.ElapsedMilliseconds}ms");

            // get job by id
            stopWa.Reset();
            stopWa.Start();
            basicOperation.GetJobById();
            stopWa.Stop();
            performanceData.AppendLine($"Get Job by Id, {stopWa.ElapsedMilliseconds}ms");

            // get job by id with navigation props
            stopWa.Reset();
            stopWa.Start();
            basicOperation.GetJobByIdWithNavigationProps();
            stopWa.Stop();
            performanceData.AppendLine($"Get one job with navigation props, {stopWa.ElapsedMilliseconds}ms");

            // get all job by id with navigation props
            stopWa.Reset();
            stopWa.Start();
            basicOperation.GetAllJobsWithNavigationProps();
            stopWa.Stop();
            performanceData.AppendLine($"Get all job with navigation props, {stopWa.ElapsedMilliseconds}ms");

            // get all jobs by tenant
            stopWa.Reset();
            stopWa.Start();
            basicOperation.GetAllJobsByTenant();
            stopWa.Stop();
            performanceData.AppendLine($"Get all jobs by tenant id , {stopWa.ElapsedMilliseconds}ms");

            // create sp 
            var storedProcedureSamples = new StoredProcedureSamples(jamsContextConnection);

            // insert agent sp
            stopWa.Reset();
            stopWa.Start();
            var agentId = storedProcedureSamples.InsertAgent();
            stopWa.Stop();
            performanceData.AppendLine($"SP Insert Agent , {stopWa.ElapsedMilliseconds}ms");

            // find agent stored procedure 
            stopWa.Reset();
            stopWa.Start();
            storedProcedureSamples.FindAgent();
            stopWa.Stop();
            performanceData.AppendLine($"SP Find Agent , {stopWa.ElapsedMilliseconds}ms");

            // get agent multi result set example 
            stopWa.Reset();
            stopWa.Start();
            storedProcedureSamples.GetAgent();
            stopWa.Stop();
            performanceData.AppendLine($"SP Get Agent , {stopWa.ElapsedMilliseconds}ms");

            // insert agent sp
            stopWa.Reset();
            stopWa.Start();
            storedProcedureSamples.DeleteAgent(agentId);
            stopWa.Stop();
            performanceData.AppendLine($"SP Delete Agent , {stopWa.ElapsedMilliseconds}ms");

            // write results in file
            File.AppendAllText(filePath, performanceData.ToString());
        }
    }
}
