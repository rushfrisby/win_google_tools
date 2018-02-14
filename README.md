# Windows tools for Google

I had two problems using Google Suite that I solved by creating these tools. The first was quickly creating a Google Doc. The second was quickly getting into a Google Hangout. The shortcuts I outline how to create below I put into my Windows Application Bar which makes it super easy to do these things.

[Download version 1.0 here](releases/latest)

## Quickly Create a Google Doc

Create a shortcut to the app and add these parameters to the target...

`"Google Docs.exe" <email address> <folder id>`

`<email address>` is the email address associated with the Google account you want to create the doc under. If you want to default to which ever account is currently active in your browser then leave this blank. Since I have a personal google account and one for work I make sure to specify this. On my work laptop it's my work email address and on my home laptop it's my personal email address.
  
`<folder id>` is the Id of the folder you want the doc created under. If you want it created in your Google Drive root then leave it blank. If not then create a folder, then grab the Id from the address bar. For example I created a folder called "test" and when I opened it the address in my browser was `https://drive.google.com/drive/u/1/folders/1gKw0O-hHduGGVejD4ARnAZjfHqrie1Az`. The Id of my folder, that I would include as the `<folder id>` parameter is `1gKw0O-hHduGGVejD4ARnAZjfHqrie1Az`

## Quickly Get Into a Google Hangout

Create a shortcut to the app and add these parameters to the target...

`"Google Hangouts.exe" <email address>`

`<email address>` is the email address associated with the Google account you want to join the hangout as. If you want to default to which ever account is currently active in your browser then leave this blank. Since I have a personal google account and one for work I make sure to specify this. On my work laptop it's my work email address and on my home laptop it's my personal email address.

When the command prompt comes up, enter the name of the Hangout you want to create or join.
