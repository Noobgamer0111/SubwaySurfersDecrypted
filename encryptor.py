import json
import os
from base64 import b64encode
from Crypto.Cipher import AES


KEY = bytes(
    [
        57, 114, 107, 120, 67, 80, 108, 106, 83,
        77, 49, 71, 86, 81, 104, 87, 119, 49, 114,
        49, 114, 75, 79, 72, 71, 99, 99, 98, 50, 105, 74, 53
    ]
)

SKIPPED_FILES = [
    "profile_flag.json",
]


def encrypt(opentext: str) -> str:
    aes = AES.new(KEY, AES.MODE_CBC, bytes(16))
    ciphertext = aes.encrypt(opentext.encode())
    buffer = b64encode(ciphertext)
    return buffer.decode()


def validate_json(json_data):
    if json_data.get("encrypted", False):
        return False
    if "data" not in json_data:
        return False
    return True


def main():
    for dirpath, dirnames, filenames in os.walk("./profile"):
        for filename in filenames:
            with open(os.path.join(dirpath, filename), "r") as file:
                if filename in SKIPPED_FILES:
                    continue
                json_data = json.loads(file.read())
                if not validate_json(json_data):
                    continue
                json_data["data"] = encrypt(json_data["data"])

            with open(os.path.join(dirpath, filename), "w") as file:
                if json_data.get("encrypted"):
                    json_data["encrypted"] = True
                file.write(json.dumps(json_data))


if __name__ == '__main__':
    main()
