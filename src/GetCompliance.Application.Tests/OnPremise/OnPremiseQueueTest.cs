using System;
using System.Diagnostics;
using GetCompliance.Application.OnPremise;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests.OnPremise
{
    public class OnPremiseQueueTest
    {
        private readonly OnPremiseQueue _sut;
        public OnPremiseQueueTest()
        {
            _sut = new OnPremiseQueue();
        }
        [Test]
        public void PutMessageTest()
        {
            // ref http://stackoverflow.com/questions/248989/unit-testing-that-an-event-is-raised-in-c-sharp
            var message = new Message();
            _sut.PutMessage(message);
            _sut.GetMessage();
        }
    }
}