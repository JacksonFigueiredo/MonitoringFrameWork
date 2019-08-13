# Monitoring FrameWork
Challenge With 1 API and 2 Services Communicating Each Other
Its a Basic Windows service that collects computer name and date time at the moment, with an API Receiving the events, and after this, a 2nd service communicating and telling if something is wrong, like an offline machine, being notified by an e-mail.

The services module are using a package called of Topshelf, easy to deploy and develop.

Instructions :


To install service : Open Command Prompt Elevated, Type ServiceName.exe install


To unistall service : Open Command Prompt Elevated, Type ServiceName.exe unistall
