using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class StreamLogger : Stream
    {
        private readonly Stream _stream;
        private readonly Action<string> _writeLogg;

        public StreamLogger(Stream stream, Action<string> writeLogg)
        {
            _stream = stream;
            _writeLogg = writeLogg;
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var content = Encoding.UTF8.GetString(buffer, offset, count);

            _writeLogg(content);

            buffer = Encoding.UTF8.GetBytes(content);

            await _stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
    }
}