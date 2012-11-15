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
### Adapter
Used to persist, load find update and delete entries.
### Entry
The entry object is a structure containing your content.
### Categoris
Use tags.
### Tags 
Yes.

#### Navigatin 
Nope. That's not minimalist.
#### Hierarchy
Nope. Not minimalist either.
#### Themes
Rally, no. Your website already has style doesn't it?
#### Something?
Ok, fine. There's a minimalist MVC4 web app to demo some ideas. Don't use it in prod. There.

Usage
======
1. Load or new up an _Entry_ adapter.
1. Create or reuse one of your action methods to intercept the route(s) of your choice.
1. Capture the slug form the URL. This is the one and only key for each entry.
1. Use the adapter to load the content, and hand it over to your view.
1. Shape the view as you wish, style it and render whichever Entry attributes make sense to you.

Other usage tips
-----------
* Use a special tag to group entries. For example "news" for news items. Then create an action and view that loads only entries tagged "news".
* Use tags as categories.
* Set the _Entry.VisibleOn_ property to a date in the future and have your action only load entries with past dates.
* Set the _Entry.VisibleOn_ to "now" to show it immediately as part of your editing logic, or _null_ postpone display.

