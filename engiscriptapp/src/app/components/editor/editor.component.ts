import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EngineService } from 'src/app/services/engine.service';
import { FilecodeService } from 'src/app/services/filecode.service';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {

  frmrun!: FormGroup;
  result!: any;
  type: number=0;
  textexample!:string;
  constructor(private serviceEngine: EngineService,
              private fileservice: FilecodeService) { }

  ngOnInit(): void {
    this.generateForm();
    this.readcodeexample0();
  }


  run(){
    debugger;

    this.result=undefined;
    let script=this.frmrun.get("script")?.value
    this.serviceEngine.getResultFromEngineStript(script,this.type).subscribe(resp=>{
    
      if(resp){
        if(Array.isArray(resp.returnValue))
            this.result=resp.returnValue.join("\n");
        else 
            this.result=resp.returnValue;
      }

    });
  }

  clear(){
    console.log("entra!!");
      this.frmrun.get("script")?.setValue("");
  }

  changeSelect(val:any){

    this.frmrun.get("script")?.setValue("");

    if(val.value==0)
      this.frmrun.get("script")?.setValue(this.readcodeexample0());
    if(val.value==1)
      this.frmrun.get("script")?.setValue(this.readcodeexample1()); 
    else if( val.value==2)
      this.frmrun.get("script")?.setValue(this.readcodeexample2());
  }


  readcodeexample0(){

    this.fileservice.readCode("codeexample0").subscribe(data=>{
      this.textexample=data;
    });

    return this.textexample
  }

  readcodeexample1(){

    this.fileservice.readCode("codeexample1").subscribe(data=>{
      this.textexample=data;
    });

    return this.textexample
  }
  readcodeexample2(){

    this.fileservice.readCode("codeexample2").subscribe(data=>{
      this.textexample=data;
    });

    return this.textexample
  }
  generateForm() {
    this.frmrun = new FormGroup({
      script: new FormControl(this.textexample, [Validators.required]),
    });
  }
}
