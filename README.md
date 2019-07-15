# Willow.Demo

## Dependencies

You will need to have Microsoft SQL Express installed with a database named "Demo", run the script DemoDBScriptQuery.sql found in /misc or as provided to populate this database.

You will also need to have npm, yarn and webpack installed.

## Starting locally

To build the client run the following command from root:

```
cd src/Willow.Demo.Client
yarn install
webpack
```

To run the application run the following command from root:

```
cd src/Willow.Demo.Api
dotnet run
```

## Testing

From root, run:

```
dotnet test
```

# Valid URLs to visit

Q3-2:

```
http://localhost:5000
```

Q3-3:

```
http://localhost:5000/api/floors
```

# Notes

You will find Q1 & Q2 answers in /misc

Total Time Taken: 5 hrs

# Improvements

I deliberately chose not to include the following features due to time constraints:

 * Use docker compose to setup, build and run both the server and database.
 * Add more Unit tests
 * Improve client validation
 * Improve server Validation
 * Add error messages
 * Add exception handling
 * Add logging
 * Hide ConnectionString
 * Health check endpoint
 * Implement Path.cs
 * HTTPS
 * Convert JobStatus to enum