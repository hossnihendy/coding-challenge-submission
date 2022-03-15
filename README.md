# American Water Coding Challege

Thank you for taking the time to work on the American Water Coding Challenge. The purpose of this challenge is to demonstrate general problem solving and programming within a set of real-world like stories.

## Instructions

1. Clone this repository to your local machine
1. Change the remote to a private remote in your GitHub account
1. Push to your GitHub account
1. Create a branch named `coding-challenge-submission` and perform your work there
1. Create a pull request from this branch to the main branch in your repository
1. Share your private repository to the following GitHub accounts - we'll need access to view the pull request as well as clone your source code:
   - https://github.com/rystroa
   - https://github.com/dickinr
   - https://github.com/cb-am
   - https://github.com/laneg-am

At a minimum, please complete the following items:

| Title              | Description                                                      |
| ------------------ | ---------------------------------------------------------------- |
| Bug #1             | Movies are not sortable                                          |
| Bug #2             | Remove duplicate movies                                          |
| Feature Request #4 | Improve UI performance by implementing a JavaScript UI framework |

You are welcome to tackle more than the minimum, though _time is very much a factor in the real world_, so carefully evaluate how much effort is invested on each of the criteria so you can complete them without impacting your outside life.

This repository contains five projects:

| Project                     | Path                           |
| --------------------------- | ------------------------------ |
| Data Access Class Library   | `./CodingChallenge.DataAccess` |
| Utility Class Library       | `./CodingChallenge.Utilities`  |
| ASP.NET MVC Web Application | `./CodingChallenge.UI`         |
| .NET Unit Tests             | `./CodingChallenge.UnitTests`  |
| Angular UI Application      | `./angular-ui`                 |

> Note: For each item below (excluding Feature Requests #3 and #4), please implement your solution in the existing projects as well as an an explanation of what you did to resolve the task. For bugs, also include a brief description of what you found wrong.

## Setup

There should be no setup required aside from downloading the source code, validating all packages are downloaded, and compiling / running the application within IIS Express. It's recommended that you use Visual Studio Community edition if you do not already have Visual Studio.

## Backlog

### Bug #1: Movies are not sortable

The movies are unable to be sorted. There are UI links in place to trigger a sort, but they do nothing. When complete, each link should be able to sort the data by their respective columns.

Some of the titles have leading articles (a/an/the). When sorting by title, provide a mechanism that excludes the leading articles, so that only the portion of the title following the article is matched on when sorting. For example, when the movie title "The Terminator" is included in the sortable list, only the title portion "Terminator" should be evaluated.

> Note: There are also unit tests wired to the sort methods on the LibraryService which currently fail. When this is corrected, each unit test should pass.

### Bug #2: Remove duplicate movies

There are movies in the library which are duplicated by Title. They show in the UI as a duplicate. Without physically removing the entries from the data store (library.xml), ensure that they no longer show in the UI.

### Feature Request #1: Filter movies by title

The Movie Library page shows all movies within the library. Implement functionality that allows the user to search movies by title.

### Feature Request #2: Show movies by franchise

A number of movies in the library belong to a franchise (for instance, Star Wars IV, V, & VI all belong to the Star Wars franchise). Update the Movie Library page so that the franchises are shown. The franchises should also be sortable.

> Note: The list of movies and what franchise they belong to are included in the UI Project under MovieFranchises.txt.

### Feature Request #3: Implement a movie library API

Using whichever technology, pattern, and practice you feel is appropriate, implement a Movie Library API which may return any number of the following results:

1. Movies in the library, filtered by title
2. Movies that are above or below a certain Rating
3. Movies between a date range
4. Movies belonging to a given franchise

### Technical Debt #1: Unit test library doesn't implement IoC

The Web Application properly implements the StructureMap IoC library; however, the Unit Test project does not. Implement StructureMap IoC within the Unit Test project.

### Feature Request #4: Improve UI performance by implementing a JavaScript UI framework

A new Angular 12 project has been scaffolded in the `./angular-ui` folder. Please modify it such that there are views to sort, filter, and page movies without reloading the entire screen. Leverage the existing endpoints in the ASP.NET MVC Web Application for data, or use what is implented in Feature Request #3 if you completed it.

> Note: Bonus points if Feature Request #1 (Filter movies by title) auto-refreshes as the user types.
