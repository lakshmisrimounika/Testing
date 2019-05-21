import { Component, OnInit } from '@angular/core';
import { zone, coordinator, campus, location, time, companyCategory, tiringDay, processCoordinator, CASIndustry } from '../Model/zone';
import { IActivateRecruiter, IcontactDetails, IcompanyDetails } from '../Model/activateRecruiters';
import { AdminService } from '../Service/service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-activaterecruiters',
  templateUrl: './activaterecruiters.component.html',
  styleUrls: ['./activaterecruiters.component.css']
})
export class ActivaterecruitersComponent implements OnInit {

  activateRecruiters: IActivateRecruiter[];
  activateRecruiter: IActivateRecruiter;

  contactDetails: IcontactDetails[];
  companyDetails: IcompanyDetails;

  selectedAll: any;
  isSelected: boolean;

  // zones: zone[] = [
  //   { value: 0, viewValue: 'North' },
  //   { value: 1, viewValue: 'South' },
  //   { value: 2, viewValue: 'East' }
  // ];

  // coordinators: coordinator[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: 'CAS admin' },
  // ];

  // campuses: campus[] = [
  //   { value: 0, viewValue: 'both' },
  //   { value: 1, viewValue: 'Hyderabad' },
  //   { value: 2, viewValue: 'Mohali' },
  // ]

  // locations: location[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: 'Domestic' },
  //   { value: 2, viewValue: 'International' },
  //   { value: 3, viewValue: 'Startup' },
  // ]

  // times: time[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: 'Old' },
  //   { value: 2, viewValue: 'New' },
  //   { value: 3, viewValue: 'Fresh' },
  // ]

  // companyCategories: companyCategory[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: 'A' },
  //   { value: 2, viewValue: 'B' },
  //   { value: 3, viewValue: 'C' },
  // ]

  // tiringdays: tiringDay[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: '0' },
  //   { value: 2, viewValue: '0.5' },
  //   { value: 3, viewValue: '1.1' },
  //   { value: 3, viewValue: '1.2' },
  //   { value: 3, viewValue: '1.3' },
  //   { value: 3, viewValue: '1.4' },
  //   { value: 3, viewValue: '1.5' },
  //   { value: 3, viewValue: '2.1' },
  // ]

  // processCoordinators: processCoordinator[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: 'Sai Sampath' },
  //   { value: 2, viewValue: 'Ramesh' },
  // ]

  // casIndustries: CASIndustry[] = [
  //   { value: 0, viewValue: '--Select--' },
  //   { value: 1, viewValue: 'Consulting' },
  //   { value: 2, viewValue: 'Engineering' },
  // ]

  // my_coordinator: object;
  // my_zones: Object;
  // my_campuses: object;
  // my_locations: object;
  // my_times: object;
  // my_companyCategories: object;
  // my_tiringdays: object;
  // my_processCoordinators: object;
  // my_casIndustries: object;

  constructor(private adminService: AdminService) {
    this.isSelected = false;
  }

  ngOnInit() {
    this.GetActivateRecruiters();
    // const _zone = {}; const _coordinator = {}; const _campus = {}; const _location = {}; const _time = {}; const _companyCategory = {};
    // const _tiringday = {}; const _processCoordinator = {}; const _casindustry = {};
    // this.my_zones = this.zones.map(single_obj => (_zone[single_obj['value']] = single_obj['viewValue']));
    // this.my_coordinator = this.coordinators.map(single_obj => (_coordinator[single_obj['value']] = single_obj['viewValue']));
    // this.my_campuses = this.campuses.map(single_obj => (_campus[single_obj['value']] = single_obj['viewValue']));
    // this.my_locations = this.locations.map(single_obj => (_location[single_obj['value']] = single_obj['viewValue']));
    // this.my_times = this.times.map(single_obj => (_time[single_obj['value']] = single_obj['viewValue']));
    // this.my_companyCategories = this.companyCategories.map(single_obj => (_companyCategory[single_obj['value']] = single_obj['viewValue']));
    // this.my_tiringdays = this.tiringdays.map(single_obj => (_tiringday[single_obj['value']] = single_obj['viewValue']));
    // this.my_processCoordinators = this.processCoordinators.map(single_obj => (_processCoordinator[single_obj['value']] = single_obj['viewValue']));
    // this.my_casIndustries = this.casIndustries.map(single_obj => (_casindustry[single_obj['value']] = single_obj['viewValue']));

  }
  companyDetail(companyId: number) {
    this.adminService.getCompanyDetalsbyId(companyId).subscribe((data: any) => {
      this.companyDetails = data.table[0];
    })
    this.adminService.getContactDetalsbyId(companyId).subscribe((data: any) => {
      this.contactDetails = data.table;
    });
  }

  GetActivateRecruiters() {    
    this.adminService.ActivateRecruiters().subscribe((data: any) => {
      this.activateRecruiters = data.table;
    })
  }

  select() {
    let selectedRecruiters = [];
    if (this.selectedAll) {
      this.activateRecruiters.forEach((item, i) => {
        if (item.selected == true) {
          selectedRecruiters.push(this.activateRecruiters[i]);
        }
      })
    }
    console.log(selectedRecruiters);
  }

  changeSelect(obj, event) {
    obj.selected = event.target.checked
    let count = 0
    for (var i = 0; i < this.activateRecruiters.length; i++) {
      if (this.activateRecruiters[i].selected == true) {
        count += 1
      }
    }
    // if(this.activateRecruiters.length == count) {
    //   this.selectedAll = true;
    // } else {
    //   this.selectedAll = false;
    // }
    this.activateRecruiters.length == count ? (this.selectedAll = true) : (this.selectedAll = false)
  }

  selectAll() {
    this.selectedAll = !this.selectedAll;
    for (var i = 0; i < this.activateRecruiters.length; i++) {
      this.activateRecruiters[i].selected = this.selectedAll;
    }
  }

  activateRe() {   
    this.select();
  }
  
  deleteRecruiters() {

  }

  Edit(id) {
    //alert(id);
  }
}
