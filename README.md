# Rubiks

Rubiks is a basic Rubik's cube simulator. You can rotate any face clockwise or anti-clockwise.

There is a basic web UI provided (using React) for testing. I have also implemented a basic solver. It gets very slow if
more than a
few steps are required to solve the cube. For this reason it is not exposed via the web api.

## Running the simulator

This easiest way is to simply access the hosted version:

https://rubiks.whoggarth.org

As a standard .NET Core project it should be straightforward to build and run the project whatever your platform and
IDE (Rubiks.Web is the startup project).

Alternatively you can build and run the project locally via docker from the project root:

```shell
    docker build -t rubiks .
    docker run -d -p 80:80 rubiks
```

The application will then be available via localhost.

If port 80 has already been bound to another service, simply change the second port number to a free port e.g.
```docker run -d -p 80:8080 rubiks ```

## Tests

The core logic of the application is covered by a suite of tests. A sample but limited solver is included in the
codebase. The tests for this solver are marked with an "Ignore" attribute as they are long running. Please comment out
this attribute if you want to check that they pass. They may take 1-2 minutes to run depending on the performance of
your
machine.

## Implementation notes

I went with a basic 6x3x3 array to represent the cube. Included is a very slow solver that works by using Dijkstra's
algorithm. I created several interfaces to demonstrate the use of dependency injection and loose coupling between the
cube and solver implementations. Potentially you could have multiple implementations of each for comparison.

The code uses general techniques and ideas. I avoided extensive research on how to represent and solve cubes as I felt
that would better demonstrate my general problem solving skills rather then replicating someone else work. Additionally
I don't own a Rubik's cube nor do I know how to solve a Rubik's cube myself!

My mother tells me as a child I did have a Rubik's cube which I solved by peeling off the coloured labels and sticking
them back on. I have no recollection of this but I like to think it shows lateral thinking skills!

The code includes some comments which should help make things a little clearer as to how and why the code is constructed
the way it is.