using Code.Gameplay.Common.Time;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Common.Visuals.Trail
{
    [RequireComponent(typeof(TrailRenderer))]
    public class TrailKeepOnPause : MonoBehaviour
    {
        private TrailRenderer trail;
        private ITimeService _timeService;

        private float originalTrailTime;

        [Inject]
        private void Construct(ITimeService timeService)
        {
            _timeService = timeService;
            trail = GetComponent<TrailRenderer>();
            originalTrailTime = trail.time;
        }

        void Update()
        {
            if (_timeService.isPaused)
                trail.time = originalTrailTime;
        }
    }
}