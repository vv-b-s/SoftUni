using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamableContent;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(File streamableContent)
        {
            this.streamableContent = streamableContent;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamableContent.BytesSent * 100) / this.streamableContent.Length;
        }
    }
}
