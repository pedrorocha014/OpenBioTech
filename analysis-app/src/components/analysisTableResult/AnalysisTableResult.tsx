import * as React from 'react';
import "./style.css";
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { IAnalysisResults } from '../../services/interfaces/IAnalysisResult';
import { useEffect, useMemo } from 'react';
import axios from 'axios';

interface Column {
    id: 'id' | 'operation' | 'message' | 'isSuccess';
    label: string;
    minWidth?: number;
    align?: 'right';
    format?: (value: number) => string;
}

type ResultsProps = {
    data: IAnalysisResults[]
}

function AnalysisTableResult() {
  const [rows, setRows] = React.useState<IAnalysisResults[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const url = 'https://localhost:44387/Register';
      const response = await axios.get<IAnalysisResults[]>(url);
      setRows(response.data);
    }

    if(!rows?.length){
      fetchData();
    } 
  }, [])

  useEffect(() => {
    console.log(rows);
  }, [rows]);

    const columns: readonly Column[] = [
  { id: 'id', label: 'Id', minWidth: 15 },
  { id: 'operation', label: 'Operation', minWidth: 50 },
  {
    id: 'message',
    label: 'Message',
    minWidth: 100,
    align: 'right',
    format: (value: number) => value.toLocaleString('en-US'),
  },
  {
    id: 'isSuccess',
    label: 'Status',
    minWidth: 50,
    align: 'right'
  }
    ];

    const mappedRows = useMemo(() => 
    { return rows
      .map((row,index) => {
        return (
          <TableRow hover role="checkbox" tabIndex={-1} key={index}>
            {columns.map((column) => {
              const value = row[column.id];
              return (
                <TableCell key={column.id} align={column.align}>
                  {column.format && typeof value === 'number'
                    ? column.format(value)
                    : value.toString()}
                </TableCell>
              );
            })}
          </TableRow>
        );
      }); }, [rows]); 

    return (
        <div id='table-container'>
            <Table stickyHeader aria-label="sticky table">
          <TableHead>
            <TableRow>
              {columns.map((column) => (
                <TableCell
                  key={column.id}
                  align={column.align}
                  style={{ minWidth: column.minWidth }}
                >
                  {column.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {mappedRows}
          </TableBody>
        </Table>
        </div>
  );
}

export default AnalysisTableResult;