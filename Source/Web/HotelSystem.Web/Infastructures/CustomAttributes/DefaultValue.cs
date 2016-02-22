namespace HotelSystem.Web.Infastructures.CustomAttributes
{
    using System;

    public class DefaultValue : Attribute
    {
        public string DefaultText { get; set; }
    }
}
