<img src="https://raw.githubusercontent.com/yemrekeskin/ApiNET/master/api.png" width="50" height="50"> 

## ApiNET
This project contain web api use-case samples to build restful services for any applications

## Technical Specifications
 - Validation - [FluentValidation](https://fluentvalidation.net/) for model validation 
 - Data Access Framework - ORM - [EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/) - Generic Repository
 - MediaTypeFormatter - [WebAPIContrib.Core](https://github.com/WebApiContrib/WebAPIContrib.Core)
 - [Json PATCH](https://tools.ietf.org/html/rfc6902) - [Microsoft.AspNetCore.JsonPatch](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/3.0.0)
 - Database - Local SQL Server 
 - Project Details
   - See [Data Model](https://raw.githubusercontent.com/yemrekeskin/ApiNET/master/src/ClassDiagram.png) by class diagram
   - See [Project Structure](https://raw.githubusercontent.com/yemrekeskin/ApiNET/master/src/ApiDesign.png)

 ### Use-Cases
 - Simple CRUD Operations 🆗
    - GET, POST, DELETE, PUT, HEAD, PATCH
 - Bulk Operations 🆗
 - Filtering, searching and paging Operations 🆗
 - Consume External API 🆗
    - HttpClient
    - ApiService
 - Request/Response Loging
 - Model Validations 🆗
 - Versioning 🆗
 - XML/JSON Output 🆗
 - MediaType Formatters
    - Plain-Text 🆗
    - CSV 🆗
    - BSON 🆗 -  [Binary JSON](http://bsonspec.org/)
 - Transactional Web Api
 - Api Licesing 🤔
 
 ### Concepts
  - Microservices 🚩
  - API Gateway 🚩
 
 ### Performance
  - Caching 🆗
      - Memory Cache 
      - Http Cache-Control
  - Asynchronous Web Api 🆗
  - Content Compression (GZIP or Deflate)
  - Faster Data Access 🤔
      - Consider alternatives ; ADO.NET, Dapper, Nosql Databases
  
 ### Security
  - Thottling Web API
    - Tiers of Throttling
       - API-level throttling
       - Application-level throttling
       - User-level throttling
       - Account-level throttling
    - Rate-Limit Throttling
    - IP-level Throttling 🆗
      - WhiteListing - Allow traffic only to known addresses
      - BlackListing - Deny traffic to known addresses
    - Scope Limit Throttling
    - Concurrent Connections Limit
    - Resource-level Throttling    
  - Authentication - JWT 🆗
  - Authorization  

 ### Testing 
  - Unit Test
  - Load Test
     - https://websurge.west-wind.com/
  - Scheduled Api Tester
     - https://uptimerobot.com/
  - Health Check Page
  - Status Page for API and System
     - https://api.twitterstat.us/
     - https://reddit.statuspage.io/
     - https://status.dropbox.com/
     - https://status.digitalocean.com/

 ### Documentation
  - Swagger 🆗
  - Postman 🆗
     - [ApiNET Services](https://documenter.getpostman.com/view/3164594/SW7XZ9Mj?version=latest)
  - API Portal  
    - https://developer.isbank.com.tr/
    - https://developer.turkishairlines.com/
    - https://apiportal.akbank.com/
    - https://apiportal.yapikredi.com.tr/
    - https://developers.garantibbva.com.tr/

 ### Tools
  - [SoapUI](https://www.soapui.org/)
  - [Postman](https://www.getpostman.com/)
  - [Fiddler](https://www.telerik.com/fiddler)
  - [Swagger](https://swagger.io/)
 
 ### Code Quality-Refactoring
  - [API Analyzer](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Api.Analyzers)
  - [CodeMaid](http://www.codemaid.net/)
 
 ### Useful Links
  - https://www.restapitutorial.com/
  - https://restfulapi.net/
 
## Contribution
Pull requests are welcome, but make sure you sign the Contributor License Agreement.

## License

ApiNET is licensed under the MIT license. Check the [LICENSE](LICENSE) file for details.
