<img src="https://raw.githubusercontent.com/yemrekeskin/ApiNET/master/api.png" width="50" height="50"> 

## ApiNET

## Data Model

## Technical Specifications
 - Validation - [FluentValidation](https://fluentvalidation.net/) for model validation 
 - Data Access Framework - ORM - [EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/) - Generic Repository
 - MediaTypeFormatter - [WebAPIContrib.Core](https://github.com/WebApiContrib/WebAPIContrib.Core)
 - Database - Local SQL Server 

## API Design

 ### Use-Cases
 - Simple CRUD Operations 🆗
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
  - Thottling - Rate Limiting - Preventing multi request 
  - Authentication - JWT
  - Authorization
  - IP Restriction 🆗
    - WhiteListing - Allow traffic only to known addresses
    - BlackListing - Deny traffic to known addresses

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
  - Swagger
  - Postman
     - [ApiNET Services](https://documenter.getpostman.com/view/3164594/SW7XZ9Mj?version=latest)
  - API Portal  
    - https://developer.isbank.com.tr/
    - https://developer.turkishairlines.com/
    - https://apiportal.akbank.com/
    - https://apiportal.yapikredi.com.tr/
    - https://developers.garantibbva.com.tr/

## Contribution
Pull requests are welcome, but make sure you sign the Contributor License Agreement.

## License

ApiNET is licensed under the MIT license. Check the [LICENSE](LICENSE) file for details.
