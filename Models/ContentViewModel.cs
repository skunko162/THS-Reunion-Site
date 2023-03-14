using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TroyHsReunionPage.Models;

public class ImagUpload
{
    public int ConentID {get;set;}
    public string Description {get;set;}
    public byte[] Image {get;set;}
}