import json
import os
from base64 import b64decode
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


def decrypt(ciphertext: str) -> str:
    aes = AES.new(KEY, AES.MODE_CBC, bytes(16))
    buffer = b64decode(ciphertext)
    decrypted_data = aes.decrypt(buffer)
    return decrypted_data.decode()


def validate_json(json_data):
    if not json_data.get("encrypted", True):
        return False
    if "data" not in json_data:
        return False
    if not json_data["data"].startswith("IegY21"):
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
                json_data["data"] = decrypt(json_data["data"])

            with open(os.path.join(dirpath, filename), "w") as file:
                if json_data.get("encrypted"):
                    json_data["encrypted"] = False
                file.write(json.dumps(json_data))


if __name__ == '__main__':
    main()
