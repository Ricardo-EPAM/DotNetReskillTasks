﻿using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage
{
    private string GetJobDescriptionText()
    {
        _logger.Debug($"Getting from vacancy description");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_vacancyDescription));
            return VacancyDescription.Text;
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetJobDescription, ex);
            throw;
        }
    }
}

