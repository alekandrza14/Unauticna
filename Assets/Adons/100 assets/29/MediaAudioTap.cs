using UnityEngine;
namespace Unauticna.MediaStudio
{
    [DisallowMultipleComponent]
    public sealed class MediaAudioTap:MonoBehaviour
    {
        public MediaCaptureWriter Sink;
        void OnAudioFilterRead(float[] data,int channels){var sink=Sink;if(sink!=null)sink.PushAudio(data,channels);}
    }
}
