using UnityEngine;

namespace SystemOfExtras
{
    public class Tiempo
    {
        private readonly int _horaAnochecer;
        private readonly int _minutoAnochecer;
        private float _seconds;
        private int _minutes, _horas;
        private bool _isNight;

        public Tiempo(int horaAnochecer, int minutoAnochecer, int hora, int minuto)
        {
            _horaAnochecer = horaAnochecer;
            _minutoAnochecer = minutoAnochecer;
            _horas = hora;
            _minutes = minuto;
        }
        
        public void AddTime(float time)
        {
            _seconds += time;
            while (_seconds>=60)
            {
                _minutes++;
                _seconds -= 60;
            }

            while (_minutes>=60)
            {
                _horas++;
                _minutes -= 60;
            }

            while (_horas >= 24)
            {
                _horas -= 24;
            }

            if (!_isNight && _horas >= _horaAnochecer && _minutes >= _minutoAnochecer)
            {
                ServiceLocator.Instance.GetService<ITimeService>().Anochecio();
                _isNight = true;
            }
        }

        public string GetTime()
        {
            return $"{_horas}:{_minutes}";
        }

        public void GoNight()
        {
            _horas = _horaAnochecer;
            _minutes = _minutoAnochecer;
        }
    }
}