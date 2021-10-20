var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
/**
 * The CarStereo defines the domain-specific interface used by the snoopDog code.
 */
var CarStereo = /** @class */ (function () {
    function CarStereo() {
    }
    CarStereo.prototype.playStereoSpeakers = function (music) {
        return 'Car Stereo goes: ' + music;
    };
    return CarStereo;
}());
/**
 * The MobilePhone contains some useful behavior, but its interface is incompatible
 * with the existing snoopDog code. The MobilePhone needs some adaptation before the
 * snoopDog code can use it.
 */
var MobilePhone = /** @class */ (function () {
    function MobilePhone(music) {
        this.setMusic(music);
    }
    MobilePhone.prototype.setMusic = function (music) {
        this._music = music;
    };
    MobilePhone.prototype.getMusic = function () {
        return this._music;
    };
    MobilePhone.prototype.playPhoneSpeakers = function () {
        return 'Phone speakers go: ' + this._music;
    };
    return MobilePhone;
}());
/**
 * The Adapter makes the MobilePhone's interface compatible with the CarStereo's
 * interface.
 */
var Adapter = /** @class */ (function (_super) {
    __extends(Adapter, _super);
    function Adapter(mobilePhone) {
        var _this = _super.call(this) || this;
        _this._mobilePhone = mobilePhone;
        return _this;
    }
    Adapter.prototype.playStereoSpeakers = function (music) {
        // const result = this._mobilePhone.specificRequest().split('').reverse().join('');
        return "Car stereo (via Adapter) goes: " + mobilePhone.getMusic();
    };
    return Adapter;
}(CarStereo));
/**
 * The snoopDog code supports all classes that follow the CarStereo interface.
 */
function snoopDogCode(carStereo) {
    console.log(carStereo.playStereoSpeakers('radio music'));
}
console.log('snoopDog: I can work just fine with the CarStereo objects:');
var carStereo = new CarStereo();
snoopDogCode(carStereo);
console.log('');
var mobilePhone = new MobilePhone('mp3 audio');
console.log('snoopDog: The MobilePhone class has a weird interface. See, I don\'t understand it:');
console.log("MobilePhone: " + mobilePhone.playPhoneSpeakers());
console.log('');
console.log('snoopDog: But I can work with it via the Adapter:');
var adapter = new Adapter(mobilePhone);
snoopDogCode(adapter);
