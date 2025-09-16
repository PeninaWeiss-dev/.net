
using BlImplementation;

namespace BlApi
{
    public static class Factory
    {
        public static IBl Get()
        {
            IBl B = new Bl();
            return B;
        }
    }
}
