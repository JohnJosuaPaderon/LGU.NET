using DPFP;
using DPFP.Capture;
using DPFP.Processing;
using System.IO;

namespace LGU
{
    public static class FingerPrintScannerHelper
    {
        public static FeatureSet ExtractFeatures(Sample sample, DataPurpose purpose)
        {
            var extraction = new FeatureExtraction();
            var feedback = CaptureFeedback.None;
            var features = new FeatureSet();
            extraction.CreateFeatureSet(sample, purpose, ref feedback, ref features);

            if (feedback == CaptureFeedback.Good)
            {
                return features;
            }
            else
            {
                return null;
            }
        }

        public static Template ExtractTemplate(Stream stream)
        {
            return stream != null ? new Template(stream) : null;
        }

        public static Template ExtractTemplate(byte[] data)
        {
            return data != null ? new Template(new MemoryStream(data)) : null;
        }
    }
}
