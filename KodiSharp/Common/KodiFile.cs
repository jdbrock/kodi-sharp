﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiFile
    {
        [JsonProperty("file")] public String FilePath { get; set; }
    }
}
