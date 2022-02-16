import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EngineService } from 'src/app/services/engine.service';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {

  frmrun!: FormGroup;
  resultarray!: Array<any>;
  result!: any;
  type!: number;
  constructor(private serviceEngine: EngineService) { }

  ngOnInit(): void {
    this.generateForm();
  }


  run(){
    debugger;
    this.resultarray=[];
    this.result=undefined;
    let script=this.frmrun.get("script")?.value
    this.serviceEngine.getResultFromEngineStript(script,this.type).subscribe(resp=>{
    
      if(resp){
        if(this.type==1)
          this.resultarray=resp;
        else
          this.result=resp.returnValue;
       
          console.log(resp);

      }

    });
  }

  clear(){
    console.log("entra!!");
    this.frmrun.get("script")?.setValue("");
    debugger;

  }

  generateForm() {
    this.frmrun = new FormGroup({
      script: new FormControl(null, [Validators.required]),
    });
  }
}
