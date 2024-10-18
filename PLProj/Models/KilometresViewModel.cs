using DALProject.Models;

namespace PLProj.Models
{
    public class KilometresViewModel
    {
        public int Id { get; set; }
        public long kiloMetres { get; set; }
        public virtual Car Car { get; set; } = null!;


        public static explicit operator KilometresViewModel(KiloMetres Model)
        {
            return new KilometresViewModel
            {
                Id = Model.Id,
                kiloMetres = Model.kiloMetres,
                Car = Model.Car
            };
        }
        public static explicit operator KiloMetres(KilometresViewModel viewModel)
        {
            return new KiloMetres
            {
                Id = viewModel.Id,
                kiloMetres = viewModel.kiloMetres,
                
            };
        }

    }
}
