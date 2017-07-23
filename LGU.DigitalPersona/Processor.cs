using DPFP;
using DPFP.Capture;
using System;

namespace LGU
{
    public abstract class Processor : DPFP.Capture.EventHandler
    {
        public Processor(Action<string> messageInvoker)
        {
            MessageInvoker = messageInvoker;
        }


        private readonly Action<string> MessageInvoker;

        public abstract void ProcessSample(Sample sample);

        public void OnComplete(object capture, string readerSerialNumber, Sample sample)
        {
            MessageInvoker("The finger print sample was captured.");
        }

        public void OnFingerGone(object capture, string readerSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnFingerTouch(object capture, string readerSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderConnect(object capture, string readerSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnReaderDisconnect(object capture, string readerSerialNumber)
        {
            throw new NotImplementedException();
        }

        public void OnSampleQuality(object capture, string readerSerialNumber, CaptureFeedback captureFeedback)
        {
            throw new NotImplementedException();
        }
    }
}
