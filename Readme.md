# GroundControl

This project was built to lay the groundwork architecture for a project in which information about various launchpads provided by the [SpaceX API](https://github.com/r-spacex/SpaceX-API/blob/master/docs/launchpad.md) are provided, filtered, and returned.
It's built in a way that allows just a manageable portion of the information retured from the API to be passed on to the caller. It also was built with the intention of allowing portions of the code based to be modified, extended, or replaced with limited disruption. (Say if a different API were used, data repository set up, or models changed.)

## What it does
- According to specified requiements, it returns Id, Name, and Status for a Launchpad when given the Id.
- Upon launching the project, a simple Get to the healthcheck endpoint will let you know everything is running.
- You are able to return a set of launchpads with filters applied to them.
    - status: allows you to specify launchpads by their status
    - namesearch: allows you to give a case sensitive string to match against any part of the full_name of the launchpad(s)
- This project currently uses V2 of the SpaceX API
- Upon launching the project you can test integration or endpoints by using the Swagger page that should automatically be brought up, or by navigating to http://localhost:63953/swagger


## How to setup
- Download or clone this repo
- You can use Visual Studio to open the sln file, and press IISExpress with the Api as your startup project. This should take you to: http://localhost:63953/swagger


## Future Plans
- Remove case sensitivity in name filtering
- Expand filtering options
- Switch API to version 3
- Swap out API for a cached database version and change the repo files
- Build out the Docker functionality to allow for containerization and deployment to an online service
- Configure Serilog Sink for use in Cloudwatch or other cloud-based logging options
- Create a UI client to view and display data