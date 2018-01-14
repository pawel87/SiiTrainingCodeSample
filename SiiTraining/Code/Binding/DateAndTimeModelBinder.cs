using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Binding
{
    public class DateAndTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var datePartName = $"{bindingContext.ModelName}.Date";
            var timePartName = $"{bindingContext.ModelName}.Time";
            var datePartValues = bindingContext.ValueProvider.GetValue(datePartName);
            var timePartValues = bindingContext.ValueProvider.GetValue(timePartName);

            if (datePartValues.Length == 0 || timePartValues.Length == 0) return Task.CompletedTask;

            DateTime.TryParseExact(
                     datePartValues.FirstValue,
                     "d",
                     CultureInfo.InvariantCulture,
                     DateTimeStyles.None,
                     out var parsedDateValue);

            DateTime.TryParseExact(
                timePartValues.FirstValue,
                "t",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal,
                out var parsedTimeValue);

            var result = new DateTime(parsedDateValue.Year,
                                    parsedDateValue.Month,
                                    parsedDateValue.Day,
                                    parsedTimeValue.Hour,
                                    parsedTimeValue.Minute,
                                    parsedTimeValue.Second);
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result, $"{datePartValues.FirstValue} {timePartValues.FirstValue}");
            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}
