# SubwaySurfersDecrypted
Figuring out the new encryption used for the Subway Surfers profile *.jsons.
This is basically an attempt to decrypt/decipher the new Version 3 of the profile *.json files stored on the Android version of Subway Surfers.

Why? Previously, the *.json files' contents used to store the user's game data in plaintext (i.e. what you see here), yet with the September 2022 update (v3.1.0), this content was encrypted, making it temporarily impossible for users with JSON editors to change out the values.

This encryption of previously-accessible content was seemingly caused by the explosion of Tiktoks and Youtube videos during July-September 2022 that provided live examples of editing JSON files to exploit in-game currency. However, this method of editing JSON files predictably angered Kiloo (publisher), given that the sale of Coins and Keys via microtransactions are the sole two sources of income for this game.

AIM: To successfully decrypt the json contents, and to be able to release tools to do so.

It is not expected that this project will be successful in any form, and I am expecting a Cease & Desist notice if Kiloo/SYBO took action against me.

Update: (29/01/2023) I have not forgotten this project. This project is tedious as my machines are both old, and weak. I'm planning to get an Android emulator running on my Ubuntu laptop, so it can done more easily.

The current plan is to locate the initialisation vector (IV) and confirm if any keys found are actually correct.

If only kids on TikTok could actually STFU about game modification, and piracy, this project would not have to exist.

Discord Server: https://discord.gg/NAXbNwKK2V