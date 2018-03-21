﻿using FanoutSearch.Standard;
using FanoutSearch.Test.TSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trinity;
using Xunit;

namespace FanoutSearch.UnitTest
{
    [Collection("All")]
    public class Traversal : IDisposable
    {
        public Traversal()
        {
            Global.LocalStorage.ResetStorage();
        }

        public void Dispose() { }

        [Fact]
        public void T1()
        {
            Global.LocalStorage.SaveMyCell(0, new List<long> { 11, 22 });
            Global.LocalStorage.SaveMyCell(11, new List<long> { 1 });
            Global.LocalStorage.SaveMyCell(22, new List<long> { 2 });
            Global.LocalStorage.SaveMyCell(1);
            Global.LocalStorage.SaveMyCell(2);

            Assert.Equal(2, g.v(0).outE("edges").outV(Action.Continue).outV(Action.Return).Count());
        }

        [Fact]
        public void T2()
        {
            Global.LocalStorage.SaveMyCell(0, new List<long> { 11, 22 });
            Global.LocalStorage.SaveMyCell(11, new List<long> { 1 });
            Global.LocalStorage.SaveMyCell(22, new List<long> { 2 });
            Global.LocalStorage.SaveMyCell(1);
            Global.LocalStorage.SaveMyCell(2);

            Assert.Equal(2, g.v(0).outV(Action.Continue).outV(Action.Return).Count());
        }
    }
}
