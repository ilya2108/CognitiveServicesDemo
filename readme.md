# Cognitive Services demo
This is a basic demo of Azure Cognitive Services based on Azure. During this demo we'll see several ways of deploying your AI into the application

# Prerequisites
For this demo there're some things should be done before making all the steps. Basically, you should have 
* Basic **C#** knowledge and asynchronous programming
* Visual Studio on Windows/Mac with Xamarin components installed
* Active Azure Suscription. All offers of Azure described [here](https://habr.com/ru/company/microsoft/blog/352786/ "Как получить подписку Microsoft Azure?") (in Russian).

# Step 1. Create a Text Analytics resource in Azure
First of all, you should create a resource in Azure. You can do it with several ways: using Azure portal or CLI tool. In this demo I'll describe a detailed instructions for Azure portal.

1. Login into the [portal](portal.azure.com "Azure portal") and click on "Create a resource" button ![alt text](https://github.com/ilia2108/CognitiveServicesDemo/blob/master/Screenshots/portal_1.png)
2. Select Text Analytics resource from either search box or "AI + Machine Learning" section ![alt text](https://github.com/ilia2108/CognitiveServicesDemo/blob/master/Screenshots/portal_2.png)
3. Fill all the data needed and click "Create" button ![alt text](https://github.com/ilia2108/CognitiveServicesDemo/blob/master/Screenshots/portal_3.png)

# Step 2. Use it in your app
Here we can distinguish two variants of API usage. They have just slight difference

## Case 1. Use an API directly
This variant assumes that you'll call this API directly from your client. Since in our case it's just a GET request, then we should be fine. There's a full [manual](https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/quickstarts/text-analytics-sdk?tabs=version-3&pivots=programming-language-csharp) for .NET Core apps

## Case 2. Azure Logic App
Direct usage of API could cost us some money, becuase app decompilation could cause a *extracting the API secrets*. In our case, this is not a radical issue, since we have just GET requests. But in other cases that could be a huge problem. So, you should *restrict the API access and do not store secrets in plaintext hardcoded*.

One of ways you can easily use is an Azure Logic App. This is a serverless service that enables you to use all Azure resources as SaaS solution. It's not complicated and doesn't require any code.

To use it you shoud:
* Create an Azure Logic App resource in Azure [portal](portal.azure.com "Azure portal")
* Go to resource
* Set up a workflow for HTTP request and add Text Analytics resource info there
* *Press "Save"* button to save all changes and generate a URL

# Test a solution
After you've created an API you can paste it into sample Xamarin.Forms app provided. You should recieve either a success message with key phrases or error message.

# Conclusion
To sum it up, this demo was about showing a basic use-case of Azure Cognitive Services. In case of any questions or suggestions don't hesitate to contact me: @ilia_2108 (VK, TG), ilia.ryabukhin@studentpartner.com
