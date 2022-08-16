using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KursachBot.Model
{
    public class Model
    {
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public string summary { get; set; }
    }

    public class Phone
    {
        [Key]
        public string phoneNumber { get; set; }
    }
}