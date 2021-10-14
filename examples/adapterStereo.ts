interface ICarStereo {
  playStereoSpeakers(s: string): string;
}

interface IMobilePhone {
  getMusic(): string,
  setMusic(music: string): void,
  playPhoneSpeakers(): string;
}

/**
 * The CarStereo defines the domain-specific interface used by the snoopDog code.
 */
class CarStereo implements ICarStereo {
  public playStereoSpeakers(music: string){
    return 'Car Stereo goes: ' + music;
  }
}

/**
 * The MobilePhone contains some useful behavior, but its interface is incompatible
 * with the existing snoopDog code. The MobilePhone needs some adaptation before the
 * snoopDog code can use it.
 */
class MobilePhone implements IMobilePhone {
  private _music: string;

  constructor(music: string){
    this.setMusic(music);
  }

  public setMusic(music: string){
    this._music = music;
  }

  public getMusic(): string {
    return this._music
  }

  public playPhoneSpeakers(): string {
    return 'Phone speakers go: ' + this._music;
  }
}

/**
 * The Adapter makes the MobilePhone's interface compatible with the CarStereo's
 * interface.
 */
class Adapter extends CarStereo {
  private _mobilePhone: MobilePhone;

  constructor(mobilePhone: MobilePhone) {
    super();
    this._mobilePhone = mobilePhone;
  }

  public playStereoSpeakers(music: string): string {
    // const result = this._mobilePhone.specificRequest().split('').reverse().join('');
    return `Car stereo (via Adapter) goes: ${mobilePhone.getMusic()}`;
  }
}

/**
 * The snoopDog code supports all classes that follow the CarStereo interface.
 */
function snoopDogCode(carStereo: CarStereo) {
  console.log(carStereo.playStereoSpeakers('radio music'))
}

console.log('snoopDog: I can work just fine with the CarStereo objects:');
const carStereo = new CarStereo();
snoopDogCode(carStereo);

console.log('');

const mobilePhone = new MobilePhone('mp3 audio');
console.log('snoopDog: The MobilePhone class has a weird interface. See, I don\'t understand it:');
console.log(`MobilePhone: ${mobilePhone.playPhoneSpeakers()}`);

console.log('');

console.log('snoopDog: But I can work with it via the Adapter:');
const adapter = new Adapter(mobilePhone);
snoopDogCode(adapter);