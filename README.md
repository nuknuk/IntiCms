IntiCms
=======

A minimalist content component that integrates into your MVC website.

Purpose
------
The goals of this project are modest yet powerful:

* To give the developer a simple component capable of fetching content
* To let content be found by slug (SEO, you know.)
* To let content be grouped or associated with tags
* To allow for - but not impose, require or bundle - any UI. Your site is your site.

Components
-----
** Adapter **
Used to persist, load find update and delete entries.
** Entry **
The entry object is a structure containing your content.
** Navigatin ** 
Nope. That's not minimalist.
** Hierarchy **
Nope. Not minimalist either.
** Themes **
Rally, no. Your website already has style doesn't it?
** Categoris **
Use tags.
** Tags **
Yes.

Usage
-----

1. Load or new up an _Entry_ adapter.
1. Create or reuse one of your action methods to intercept the route(s) of your choice.
1. Capture the slug form the URL. This is the one and only key for each entry.
1. Use the adapter to load the content, and hand it over to your view.
1. Shape the view as you wish, style it and render whichever Entry attributes make sense to you.

** Categorization and tagging **
