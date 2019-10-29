# OnceUponATime
A Virtual Reality app for Android which converts speech to virtual scenarios in real-time

## Inspiration
In our modern world, the younger generation tends to indulge in using their electronics, while the older generation would prefer that they read a book. Our team believes that these two notions do not need to contradict each other. Once Upon a Time can once again spark children's interest in reading by seamlessly fusing their fairy tales with real-time VR experiences!

## What it does
Once Upon A Time is a Unity app that dynamically and remotely generates a Virtual Reality world based on a story currently being spoken into a microphone.

## How we built it
We built a Node.js app which streams live speech to IBM Watson and parses the resulting text to VR commands. We then send forward these web socket commands to the Unity App in real-time.

## Challenges we ran into
Predominantly, our challenges included displaying the 3D models in the correct locations, and moving/rotating them to an accurate destination/orientation. Furthermore, linking the Node.js server to the Unity app via Socket.IO proved to be a challenge which we also eventually overcame.

## Accomplishments that we're proud of
We're proud of what we accomplished in less than 36 hours! We were able to invent a product which had never been built before, and have 3D models that display in a VR according to a story that is told.

## What we learned
We learned how to use a Game Engine, and stream data from a server to a mobile application dynamically.

## What's next for Once Upon A Time
We are very excited about this idea, and the resultant product we were able to develop from the ground up! In order to let Once Upon a Time realize its potential, we intend to explore options for diversifying our 3d model database to support more story books. Once this app is fully polished, we look forward to making it available for the public on the Google Play Store.
