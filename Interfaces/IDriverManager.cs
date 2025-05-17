using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Interfaces;

public interface IDriverManager
{
    IWebDriver CreateDriver(bool isHeadless);
}
