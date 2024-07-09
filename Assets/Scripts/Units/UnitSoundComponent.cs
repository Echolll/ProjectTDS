using UnityEngine;

namespace ProjectTDS.Unit
{
    [RequireComponent(typeof(AudioSource))]
    public class UnitSoundComponent : UnitComponent
    {
        [SerializeField]
        private AudioClip _walkSound;
        [SerializeField]
        private AudioClip _deadSound;

        private AudioSource _source;

        private void OnEnable() => _source = GetComponent<AudioSource>();

        public void PlayWalkSound(Vector3 currentVelocity)
        {
            if(currentVelocity.sqrMagnitude >= 0.25)
            {
                if (_source.isPlaying) return;
                _source.PlayOneShot(_walkSound);
            }          
            else _source.Stop();
        }

        public void UnitDeadSound()
        {
            _source.loop = false;
            _source.outputAudioMixerGroup = null;
            _source.PlayOneShot(_deadSound, 0.8f);
        }
    }
}
