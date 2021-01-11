# ImageUpload

### Uploads Images... That's about it.

ImageUpload is a Xamarin.Forms application that uploads images through Imgur. It saves uploads to a local cached database. That's about it!

## Setup
---

In order to deploy ImageUpload, you must setup `secrets.json` in the [ImageUpload.Mobile](ImageUpload.Mobile/ImageUpload.Mobile) Class Library. This contains the Imgur API keys.

```
{
  "ImgurApiClientKey": "(CLIENT KEY)",
  "ImgurApiClientSecret": "(CLIENT SECRET)"
}

```

You can generate these keys on the [Imgur API Site](https://api.imgur.com/oauth2/addclient).
