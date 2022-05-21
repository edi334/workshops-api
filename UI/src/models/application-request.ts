import {Application} from "./application";

export interface ApplicationRequest extends Application {
  participantId: string;
  workshopId: string;
}
