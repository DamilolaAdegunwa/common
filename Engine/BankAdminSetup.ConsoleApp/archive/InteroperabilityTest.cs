﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Numerics;
using System.ServiceProcess;
/// <summary>
/// This is the CodeSnippet.ConsoleApp namespace, used for testing lots of c# code and algorithms
/// </summary>
namespace CodeSnippet.ConsoleApp
{
    /// <summary>
    /// Interoperability: this run test for understanding codes bordering managed and managed code...
    /// </summary>
    /// <remarks>
    /// We test for COM, COM+, C++/CLI, WINDOWS API, Active X etc. 
    /// </remarks>
    public class InteroperabilityTest
    {
        public void Method1()
        {
            var s = new System.Numerics.Complex();
            var a = System.ServiceProcess.StartInfo.FileName;
		}
    }
}
