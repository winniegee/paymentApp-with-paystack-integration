import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalizeTransferComponent } from './finalize-transfer.component';

describe('FinalizeTransferComponent', () => {
  let component: FinalizeTransferComponent;
  let fixture: ComponentFixture<FinalizeTransferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinalizeTransferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinalizeTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
