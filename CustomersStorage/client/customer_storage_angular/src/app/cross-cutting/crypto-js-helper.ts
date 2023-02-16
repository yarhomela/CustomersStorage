import  *  as CryptoJS from  'crypto-js';

export class CryptoJsHelper{
    private cryptoSecretKey = "well-known";

    public encrypt(txt: string): string {
        let encryptObject = CryptoJS.AES.encrypt(txt, this.cryptoSecretKey);
        return encryptObject.toString();
    }
    
    public decrypt(txtToDecrypt: string) {
        let encryptObject = CryptoJS.AES.decrypt(txtToDecrypt, this.cryptoSecretKey);
        return encryptObject.toString(CryptoJS.enc.Utf8);
    }
}