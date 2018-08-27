namespace DMSC.Assessment.Data.Interface
{
    using DMSC.Assessment.Data.Model;

    using System;
    public interface IChartRepository
    {
        Chart Get(DateTime dateTime);
    }
}
