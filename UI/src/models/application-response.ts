import {Application} from "./application";
import {Participant} from "./participant";
import {Workshop} from "./workshop";

export interface ApplicationResponse extends Application {
  participant: Participant;
  workshop: Workshop;
}
