# ChatApplication
<div>
<h2>Goal</h2>
<p>The goal of this project is to create a fast-running chat application with a strong back-end and API system, minimizing the front-end's workload.</p>

<h3>Models</h3>
<li>User</li>
<li>Chat</li>
<li>Message</li>

<h2>Chat response example:</h2>
<h5>api/v1/Chats/{id} Response</h5>
<img width="40%" src="https://user-images.githubusercontent.com/101286736/231768920-f1139240-8aa1-4fdf-b7fb-107b9833e00a.png"/>

<h2>Response Usage In Front-End</h2>
<p>
The "Message" model contains a "Type" property that can be set to Alert, Error, Normal, or Green, which defines the color of the message. The response model will return a hexadecimal string value for the corresponding color.

In the "Chat" model, we define senders and receivers based on whoever initiated the first message. This helps us filter deleted messages from each person's point of view. For example, a user can delete a message, but it will still be shown to the other user even if it's deleted. That's why we have "SenderDeletedMessages" and "ReceiverDeletedMessages" properties that hold IDs for deleted messages on each side.

When displaying messages on the front-end, we will filter out the messages that are in these lists.
</p>
</div>
