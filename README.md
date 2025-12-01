## ⚠️ disclaimer

this tool is intended **for educational and testing purposes only**.  
do **not** use it for any unauthorized access, password cracking, or activity that violates privacy, laws, or security policies.  
the author is **not responsible** for any misuse or illegal actions performed with this software.

# hash cracker (sha-256)

a simple sha-256 hash cracking tool. the project includes two main components:

- **hash cracker** → compares each word in the wordlist against the target sha-256 hash  
- **wordlist generator (optional)** → creates a brute‑force wordlist with your chosen length

---

## 🔧 how it works

### 1. creating a wordlist (optional)

when the program starts, it asks:

generate a new wordlist? (y/n):

- if you choose **y**, it generates a wordlist using lowercase letters + digits  
- it automatically saves to **wordlist.txt**

> you may also use your **own** wordlist. just make sure the file is named **wordlist.txt**.

---

### 2. cracking the hash

the program then asks for the target hash:

target sha256 hash:


it hashes each word from the wordlist and compares it.  

- if a match is found → the password is shown  
- if no match exists → the search ends with a warning

---

## 📁 project structure

/hashCracker
├── Program.cs -> main hash cracker
├── createWordlist.cs -> optional wordlist generator
├── wordlist.txt -> your wordlist file (auto or manual)
└── README.md

---

## ▶️ usage

1. build and run the project  
2. choose whether to generate a new wordlist  
3. enter your target sha‑256 hash  
4. results appear in the console with colored output

---

## 📌 notes

- the wordlist file **must** be named `wordlist.txt`  
- supported characters for generation: `a-z` and `0-9`  
- only sha‑256 is supported by default (but easily extendable)

---

## 📜 license

this tool is for educational purposes only. MIT LICENSE