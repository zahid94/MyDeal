using MyDeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service
{
    public interface IHomePageSliderService:IDisposable
    {
        HomePageSlider AddSlider(HomePageSlider Slider);
        bool UpdateSlider(HomePageSlider Slider);
        bool RemoveSlider(HomePageSlider Slider);
        HomePageSlider SliderDetails(Expression<Func<HomePageSlider, bool>> expression);
        IEnumerable<HomePageSlider> GetAll(Expression<Func<HomePageSlider, bool>> expression);
    }
}
