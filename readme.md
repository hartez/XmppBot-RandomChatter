# Random Chatter Plugin for XmppBot

This is a simple plugin for [XmppBot For HipChat](https://github.com/patHyatt/XmppBot-for-HipChat). It loads up a text file of phrases which will be randomly interjected into conversations by the bot. 

## Installation

Copy the .dlls (Bender.dll, SimpleConfig.dll, XmppBot.Common.dll, and XmppBot-RandomChatter.dll) into the /plugins folder. 

## Configuration

Add the following to the `<configSections>` element of XmppBot's configuration file:

    <section name="randomChatterConfig" type="SimpleConfig.Section, SimpleConfig, Version=1.0.29.0, Culture=neutral, PublicKeyToken=null"/>

Then add the following to the `configuration ` element:

	<randomChatterConfig PercentChanceOfResponse="1" ResponsesFilePath="plugins/Responses.txt">
  	</randomChatterConfig>

Where `PercentChanceOfResponse` is an integer from 0 to 100 indicating how likely the bot will interject a response to any input, and `ResponsesFilePath` is the path to the text file containing the possible phrases.

