using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJobTest
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("afro")] String message, TextWriter log, IBinder binder, Int32 dequeueCount)
        {
            log.WriteLine("este es el intento numero{0}", dequeueCount);
            if (dequeueCount <= 5)
            {
                binder.Bind<QueueAttribute>(new QueueAttribute("afro-poison"));
            }
            throw new Exception("throw perra");
        }

        public static void ProcessQueueMessagePoison([QueueTrigger("afro-poison")] String message, TextWriter log)
        {
            log.WriteLine("afro envenenado");
        }
    }
}
