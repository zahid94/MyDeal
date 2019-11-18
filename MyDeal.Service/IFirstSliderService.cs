using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IFirstSliderService:IDisposable
    {
        FirstSlider AddSlider(FirstSlider Slider);
        bool UpdateSlider(FirstSlider Slider);
        bool RemoveSlider(FirstSlider Slider);
        FirstSlider SliderDetails(Expression<Func<FirstSlider, bool>> expression);
        IEnumerable<FirstSlider> GetAll(Expression<Func<FirstSlider, bool>> expression);
    }
}
