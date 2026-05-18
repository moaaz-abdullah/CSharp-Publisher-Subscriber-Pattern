# YouTube Channel Event System

A small educational C# console application that demonstrates the use of:

- Delegates
- Events
- EventHandler<T>
- Observer Pattern
- Event-driven programming

This project simulates a simple YouTube channel system where subscribers receive notifications when a new video is uploaded.

---

## Features

- Upload videos from a YouTube channel
- Subscribers can subscribe/unsubscribe
- Send notifications when a new video is uploaded
- Add automatic comments
- Simulate email notifications
- Demonstrates loose coupling using events

---

## Concepts Practiced

This project was built mainly for learning and revision purposes.

Topics covered:
- C# Events
- Delegates
- Custom EventArgs
- Observer Pattern
- Pub/Sub basics
- Decoupled architecture

---

## Project Structure

### YoutubeChannel
Acts as the publisher (subject).

Responsible for:
- Uploading videos
- Triggering events

### Subscriber
Represents users watching the channel.

Responsible for:
- Subscribing to notifications
- Watching uploaded videos

### Comments
Automatically adds comments when a video is uploaded.

### Notify
Simulates sending email notifications to subscribers.

---

## Example Flow

```text
1. Subscribers subscribe to the channel
2. Channel uploads a video
3. Event is triggered
4. All subscribers receive notifications
5. Comments and email notifications are executed
